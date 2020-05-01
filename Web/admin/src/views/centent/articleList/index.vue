<template>
  <div class="app-container">
    <div class="filter-container" style="padding-bottom:10px">
      <el-input
        v-model="listQuery.title"
        placeholder="标题"
        style="width: 200px;"
        class="filter-item"
        @keyup.enter.native="handleFilter"
      />
      <el-button class="filter-item" type="primary" icon="el-icon-search" @click="handleFilter">搜索</el-button>
      <router-link :to="'/centent/add/'" class="link-type">
      <el-button
        class="filter-item"
        style="margin-left: 10px;"
        type="primary"
        icon="el-icon-edit"
      >添加</el-button>
      </router-link>
    </div>
    <el-table
      border
      fit
      v-loading="listLoading"
      :data="tableData"
      stripe
      highlight-current-row
      style="width: 100%"
    >
      <el-table-column prop="id" label="编号" />
      <el-table-column prop="title" label="标题" />
      <el-table-column prop="sourceLink" label="来源" />
      <el-table-column prop="categoryId" label="分类" />
      <el-table-column prop="createDate" label="日期" :formatter="dateFormat"/>
      <el-table-column label="操作">
        <template slot-scope="{row}">
          <router-link :to="'/centent/edit?id='+row.id" class="link-type">
           <el-button type="primary" size="small" icon="el-icon-edit">
              编辑
            </el-button>
          </router-link>
          <el-button size="mini" type="danger" @click="handlDeleteData(row)">删除</el-button>
        </template>
      </el-table-column>
    </el-table>

    <Pagination
      v-show="total>0"
      :total="total"
      :page.sync="listQuery.page"
      :limit.sync="listQuery.limit"
      @pagination="getList"
    />
  </div>
</template>
<script>
import { getArticleList, remove } from '@/api/article'
import store from '@/store'
import Pagination from '@/components/Pagination'
export default {
  name: 'AticleTable',
  components: { Pagination },
  data() {
    return {
      tableData: [],
      list: null,
      total: 0,
      listLoading: true,
      listQuery: {
        page: 1,
        limit: 10,
        title: ''
      },
      textMap: {
        update: '编辑',
        create: '添加'
      },
      temp: {
        id: '',
        content: '',
        title: '',
        summary: '',
        remarks: ''
      },
      dialogStatus: '',
      dialogFormVisible: false,
      rules: {
        name: [
          { required: true, message: 'name is required', trigger: 'blur' }
        ]
      }
    }
  },
  created() {
    this.getList()
    this.temp.content = '测试'
  },
  methods: {
    getList() {
      this.listLoading = true
      getArticleList(this.listQuery).then(response => {
        this.tableData = response.data.items
        this.total = response.data.totalCount
        setTimeout(() => {
          this.listLoading = false
        }, 1.5 * 1000)
      })
    },
    dateFormat: function(row, column) {
      var t = new Date(row.createDate)// row 表示一行数据, updateTime 表示要格式化的字段名称
      return t.getFullYear() + '-' + (t.getMonth() + 1) + '-' + t.getDate() + ' ' + t.getHours() + ':' + t.getMinutes() + ':' + t.getSeconds()
    },
    resetTemp() {
      this.temp = {
        id: '',
        title: '',
        summary: '',
        remarks: ''
      }
    },
    handleFilter() {
      this.getList()
    },
    handlDeleteData(row) {
      const userId = store.state.user.userId
      remove(row.id, userId).then(() => {
        this.$notify({
          title: '提示',
          message: '删除成功',
          type: 'success',
          duration: 2000
        })
        this.getList()
      })
    }
  }
}
</script>
