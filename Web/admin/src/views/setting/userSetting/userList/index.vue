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
      <el-input
        v-model="listQuery.phone"
        placeholder="联系方式"
        style="width: 250px;"
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
      <el-table-column prop="name" label="姓名" />
      <el-table-column prop="email" label="邮箱" />
      <el-table-column prop="phone" label="联系方式" />
      <el-table-column prop="sex" label="性别" :formatter="sexFormat"/>
      <el-table-column prop="age" label="年龄" />
      <el-table-column prop="roleID" label="角色" />
      <el-table-column prop="areaID" label="区域" />
      <el-table-column prop="createDate" label="创建日期" :formatter="dateFormat"/>
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
        <el-form-item label="姓名" prop="name">
          <el-input v-model="temp.name" />
        </el-form-item>
        <el-form-item label="性别" prop="sex" >
          <el-select v-model="temp.sex" class="filter-item" placeholder="请选择性别">
            <el-option
              v-for="item in sexTypeOptions"
              :key="item.key"
              :label="item.display_name"
              :value="item.key"
            />
          </el-select>
        </el-form-item>
        <el-form-item label="邮箱" prop="email">
          <el-input v-model="temp.email" />
        </el-form-item>
        <el-form-item label="密码" prop="password">
          <el-input v-model="temp.password"/>
        </el-form-item>
        <el-form-item label="手机号码" prop="phone">
          <el-input v-model="temp.phone" />
        </el-form-item>
        <el-form-item label="年龄" prop="age">
          <el-input v-model="temp.age" />
        </el-form-item>
        <el-form-item label="角色" prop="roleID">
          <el-select v-model="temp.roleID" class="filter-item" placeholder="请选择角色">
            <el-option
              v-for="item in roleTypeOptions"
              :key="item.id"
              :label="item.name"
              :value="item.id"
            />
          </el-select>
        </el-form-item>
        <el-form-item label="地区" prop="areaID">
           <el-select v-model="temp.areaID" class="filter-item" placeholder="请选择区域">
            <el-option
              v-for="item in areaTypeOptions"
              :key="item.id"
              :label="item.state+item.province+item.city+item.street"
              :value="item.id"
            />
          </el-select>
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
  getUserList,
  // eslint-disable-next-line no-unused-vars
  getUser,
  createUser,
  updateUser,
  deleteUser
} from '@/api/user'
import { getRoleList } from '@/api/role'
import { getAreaList } from '@/api/area'
import store from '@/store'
import Pagination from '@/components/Pagination'
const sexTypeOptions = [
  { key: '0', display_name: '男' },
  { key: '1', display_name: '女' }
]
const roleTypeOptions = []
const areaTypeOptions = []
export default {
  name: 'UserTable',
  components: { Pagination },
  data() {
    return {
      userId: store.state.user.userId,
      sexTypeOptions,
      roleTypeOptions,
      areaTypeOptions,
      dialogTableVisible: false,
      tableData: [],
      tableKey: 0,
      total: 0,
      listLoading: true,
      listQuery: {
        page: 1,
        limit: 20,
        name: '',
        phone: ''
      },
      listRoleQuery: {
        page: 1,
        limit: 2000
      },
      listAreaQuery: {
        page: 1,
        limit: 2000
      },
      dialogStatus: '',
      dialogFormVisible: false,
      textMap: {
        update: '编辑',
        create: '添加'
      },
      temp: {
        id: '',
        name: '',
        password: '',
        email: '',
        phone: '',
        sex: '',
        age: '',
        roleID: '',
        areaID: '',
        createDate: ''
      },
      rules: {
        name: [
          { required: true, message: 'name is required', trigger: 'blur' }
        ],
        sex: [
          {
            required: true,
            message: 'timestamp is required',
            trigger: 'change'
          }
        ]
      }
    }
  },
  created() {
    this.getList()
    this.getRoleList()
    this.getAreaList()
  },
  methods: {
    getList() {
      this.listLoading = true
      getUserList(this.listQuery).then(response => {
        this.tableData = response.data.items
        this.total = response.data.totalCount
        // Just to simulate the time of the request
        setTimeout(() => {
          this.listLoading = false
        }, 1.5 * 1000)
      })
    },
    getRoleList() {
      getRoleList(this.listRoleQuery).then(response => {
        this.roleTypeOptions = response.data.items
        setTimeout(() => {
          this.listLoading = false
        }, 1.5 * 1000)
      })
    },
    getAreaList() {
      getAreaList(this.listAreaQuery).then(response => {
        this.areaTypeOptions = response.data.items
        setTimeout(() => {
          this.listLoading = false
        }, 1.5 * 1000)
      })
    },
    dateFormat: function(row, column) {
      var t = new Date(row.createDate)// row 表示一行数据, updateTime 表示要格式化的字段名称
      return t.getFullYear() + '-' + (t.getMonth() + 1) + '-' + t.getDate() + ' ' + t.getHours() + ':' + t.getMinutes() + ':' + t.getSeconds()
    },
    sexFormat: function(row, column) {
      var result = ''
      if (row.sex === 0) {
        result = '男'
      } else {
        result = '女'
      }
      return result
    },
    resetTemp() {
      this.temp = {
        id: '',
        name: '',
        password: '',
        email: '',
        phone: '',
        sex: '',
        age: '',
        roleID: '',
        areaID: '',
        createDate: ''
      }
    },
    fetchUser() {},
    handleFilter() {
      this.listQuery.page = 1
      this.getList()
    },
    handleCreate() {
      this.resetTemp()
      this.dialogStatus = 'create'
      this.dialogFormVisible = true
      this.$nextTick(() => {
        this.$refs['dataForm'].clearValidate()
      })
    },
    handleUpdate(row) {
      this.temp = Object.assign({}, row) // copy obj
      this.temp.sex = Number(row.sex)
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
          createUser(this.temp).then(() => {
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
          updateUser(tempData).then(() => {
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
      deleteUser(row.id, this.userId).then(() => {
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
