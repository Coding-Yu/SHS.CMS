<template>
  <div class="app-container">
    <div class="filter-container" style="padding-bottom:10px">
      <el-input
        v-model="listQuery.zipCode"
        placeholder="邮政编码"
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
      <el-table-column prop="state" label="国家" />
      <el-table-column prop="province" label="省份" />
      <el-table-column prop="city" label="城市" />
      <el-table-column prop="street" label="街道" />
      <el-table-column prop="zipCode" label="邮政编码"/>
      <el-table-column label="操作">
        <template slot-scope="{row}">
          <el-button size="mini" @click="handleUpdate(row)">编辑</el-button>
          <el-button size="mini" type="danger" @click="deleteData(row)">删除</el-button>
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
         <el-form-item label="国家" prop="state">
          <el-input v-model="temp.state" />
        </el-form-item>
        <el-form-item label="省份" prop="province">
          <el-input v-model="temp.province"/>
        </el-form-item>
        <el-form-item label="城市" prop="city">
          <el-input v-model="temp.city"/>
          </el-form-item>
        <el-form-item label="街道" prop="street">
          <el-input v-model="temp.street" />
        </el-form-item>
        <el-form-item label="邮政编码" prop="zipCode">
          <el-input v-model="temp.zipCode" />
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
import {
  getAreaList,
  // eslint-disable-next-line no-unused-vars
  getDetail,
  add,
  update,
  remove
} from '@/api/area'
import store from '@/store'
import Pagination from '@/components/Pagination'

export default {
  name: 'UserTable',
  components: { Pagination },
  data() {
    return {
      userId: store.state.user.userId,
      dialogTableVisible: false,
      tableData: [],
      tableKey: 0,
      total: 0,
      listLoading: true,
      listQuery: {
        page: 1,
        limit: 20,
        zipCode: ''
      },
      dialogStatus: '',
      dialogFormVisible: false,
      textMap: {
        update: '编辑',
        create: '添加'
      },
      temp: {
        id: '',
        street: '',
        city: '',
        state: '',
        zipCode: '',
        province: ''
      },
      rules: {
        state: [
          { required: true, message: 'state is required', trigger: 'blur' }
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
      getAreaList(this.listQuery).then(response => {
        this.tableData = response.data.items
        this.total = response.data.totalCount
        // Just to simulate the time of the request
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
        street: '',
        city: '',
        state: '',
        zipCode: '',
        province: ''
      }
    },
    handleFilter() {
      this.listQuery.page = 1
      this.getList()
    },
    handleCreate() {
      console.log(this.$refs['dataForm'])
      this.resetTemp()
      this.dialogStatus = 'create'
      this.dialogFormVisible = true
      this.$nextTick(() => {
        this.$refs['dataForm'].clearValidate()
      })
    },
    handleUpdate(row) {
      this.temp = Object.assign({}, row) // copy obj
      this.dialogStatus = 'update'
      this.dialogFormVisible = true
      this.$nextTick(() => {
        this.$refs['dataForm'].clearValidate()
      })
    },
    createData() {
      this.$refs['dataForm'].validate(valid => {
        if (valid) {
          this.temp.createDate = undefined
          this.temp.id = undefined
          this.temp.createuserId = this.userId
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
          this.temp.updateuserId = this.userId
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
    deleteData(row) {
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
