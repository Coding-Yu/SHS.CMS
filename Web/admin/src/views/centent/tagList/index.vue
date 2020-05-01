<template>
  <div class="app-container">
    <div class="filter-container" style="padding-bottom:10px">
      <el-input
        v-model="listQuery.name"
        placeholder="名称"
        style="width: 200px;"
        class="filter-item"
        @keyup.enter.native="handleFilter"
      />
      <el-button class="filter-item" type="primary" icon="el-icon-search" @click="handleFilter">搜索</el-button>
      <el-button
        class="filter-item"
        style="margin-left: 10px;"
        type="primary"
        icon="el-icon-edit"
        @click="handleCreate"
      >添加</el-button>
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
      <el-table-column prop="name" label="名称" />
      <el-table-column prop="summary" label="简介" />
      <el-table-column prop="createDate" label="日期" :formatter="dateFormat"/>
      <el-table-column label="操作">
        <template slot-scope="{row}">
          <el-button size="mini" @click="handleUpdate(row)">编辑</el-button>
          <el-button size="mini" type="danger" @click="handlDeleteData(row)">删除</el-button>
        </template>
      </el-table-column>
    </el-table>

    <Pagination
      background
      v-show="total>0"
      :total="total"
      :page.sync="listQuery.page"
      :limit.sync="listQuery.limit"
      @pagination="getList"
    />

    <el-dialog :title="textMap[dialogStatus]" :visible.sync="dialogFormVisible">
      <el-form
        ref="dataForm"
        :rules="rules"
        :model="temp"
        label-position="left"
        label-width="70px"
        style="width: 400px; margin-left:50px;"
      >
        <el-form-item label="名称" prop="name">
          <el-input v-model="temp.name" />
        </el-form-item>
        <el-form-item label="简介" prop="summary">
          <el-input v-model="temp.summary"/>
        </el-form-item>
        <el-form-item label="备注" prop="remarks">
          <el-input type="textarea" v-model="temp.remarks" />
        </el-form-item>
      </el-form>
      <div slot="footer" class="dialog-footer">
        <el-button @click="dialogFormVisible = false">取消</el-button>
        <el-button type="primary" @click="dialogStatus==='create'?createData():updateData()">确认</el-button>
      </div>
    </el-dialog>
  </div>
</template>
<script>
import { getTagList, add, update, remove } from '@/api/tag'
import store from '@/store'
import Pagination from '@/components/Pagination'
export default {
  name: 'TagTable',
  components: { Pagination },
  data() {
    return {
      userId: store.state.user.userId,
      tableData: [],
      list: null,
      total: 0,
      listLoading: true,
      listQuery: {
        page: 1,
        limit: 20,
        name: ''
      },
      textMap: {
        update: '编辑',
        create: '添加'
      },
      temp: {
        id: '',
        name: '',
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
  },
  methods: {
    getList() {
      this.listLoading = true
      getTagList(this.listQuery).then(response => {
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
        name: '',
        summary: '',
        remarks: ''
      }
    },
    handleFilter() {
      this.getList()
    },
    handleCreate() {
      this.resetTemp()
      this.dialogFormVisible = true
      this.dialogStatus = 'create'
      this.$nextTick(() => {
        this.$refs['dataForm'].clearValidate()
      })
    },
    handleUpdate(row) {
      this.temp = Object.assign({}, row)
      this.dialogFormVisible = true
      this.dialogStatus = 'update'
    },
    createData() {
      this.$refs['dataForm'].validate(valid => {
        if (valid) {
          this.temp.id = undefined
          this.temp.createUserId = this.userId
          add(this.temp).then(() => {
            this.dialogFormVisible = false
            this.$notify({
              title: '提示',
              message: '添加成功',
              type: 'success',
              duration: 2000
            })
            this.getList()
          })
        }
      })
    },
    updateData() {
      this.$refs['dataForm'].validate(valid => {
        if (valid) {
          this.temp.updateUserId = this.userId
          const tempData = Object.assign({}, this.temp)
          update(tempData).then(() => {
            this.dialogFormVisible = false
            this.$notify({
              title: '提示',
              message: '更新成功',
              type: 'success',
              duration: 2000
            })
            this.getList()
          })
        }
      })
    },
    handlDeleteData(row) {
      remove(row.id, this.userId).then(() => {
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
