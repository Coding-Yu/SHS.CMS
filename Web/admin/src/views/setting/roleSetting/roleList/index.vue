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
      <el-checkbox v-model="listQuery.isDefault">是否默认</el-checkbox>
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
      <el-table-column prop="isDefault" label="是否默认" >
      </el-table-column>
      <el-table-column prop="summary" label="简介" />
      <el-table-column prop="createDate" label="日期" :formatter="dateFormat"/>
      <el-table-column label="操作">
        <template slot-scope="{row}">
          <el-button size="mini" @click="handleUpdate(row)">编辑</el-button>
          <el-button size="mini" type="danger" @click="handlDeleteData(row)">删除</el-button>
          <el-button size="mini" @click="handleSetPermission(row)">设置权限</el-button>
        </template>
      </el-table-column>
    </el-table>

    <el-pagination
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
        <el-form-item label="是否默认" prop="isDefault">
          <el-checkbox v-model="temp.isDefault" ></el-checkbox>
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
    <el-dialog :title="permissionStatus" :visible.sync="permissionBindingFormVisible" >
      <el-form
        ref="permissionDataForm"
        :rules="setPermissionRules"
        :model="temp"
        label-position="left"
        label-width="70px"
        style="width: 400px; margin-left:50px;"
      >
      <el-checkbox-group v-model="permissionGroupList" >
        <el-checkbox v-for="(item,index) in permissionList" :key="index+setPermissionState"  :label="item.title" :value="item.id" :checked="item.ischeck"></el-checkbox>
      </el-checkbox-group>
      </el-form>
      <div slot="footer" class="dialog-footer">
        <el-button @click="permissionBindingFormVisible = false">取消</el-button>
        <el-button type="primary" @click="setPermission()">确认</el-button>
      </div>
    </el-dialog>
  </div>
</template>
<script>
//, add, update, remove, setPermission
import { getRoleList, add, update, remove, setPermission, getPermissionByRoleId } from '@/api/role'
import { getPermissionList } from '@/api/permission'
export default {
  data() {
    return {
      tableData: [],
      list: null,
      total: 0,
      listLoading: true,
      listQuery: {
        page: 1,
        limit: 20,
        name: '',
        isDefault: ''
      },
      permissionStatus: '权限绑定',
      permissionGroupList: [],
      permissionList: [],
      permissionListQuery: {
        page: 1,
        limit: 20
      },
      textMap: {
        update: '编辑',
        create: '添加'
      },
      currentCheckRole: '',
      currentCheckRolePermission: [],
      temp: {
        id: '',
        name: '',
        isDefault: false,
        summary: '',
        remarks: ''
      },
      dialogStatus: '',
      dialogFormVisible: false,
      permissionBindingFormVisible: false,
      rules: {
        name: [
          { required: true, message: 'name is required', trigger: 'blur' }
        ]
      },
      setPermissionRules: {

      },
      setPermissionState: 1
    }
  },
  created() {
    this.getList()
  },
  methods: {
    getList() {
      this.listLoading = true
      getRoleList(this.listQuery).then(response => {
        this.tableData = response.data
        this.total = 1
        setTimeout(() => {
          this.listLoading = false
        }, 1.5 * 1000)
      })
    },
    getPermissionList(row) {
      getPermissionList(this.permissionListQuery).then(permission => {
        getPermissionByRoleId(row.id).then(permissionByRole => {
          if (permissionByRole.data.length <= 0) {
            permission.data.forEach(permissionItems => {
              this.permissionList.push({ id: permissionItems.id, title: permissionItems.name, ischeck: false })
            })
          } else {
            permission.data.forEach(permissionItems => {
              permissionByRole.data.forEach(permissionByRoleItems => {
                console.log('权限ID', permissionItems.id, '拥有ID', permissionByRoleItems.id)
                if (permissionItems.id === permissionByRoleItems.id) {
                  this.permissionList.push({ id: permissionItems.id, title: permissionItems.name, ischeck: true })
                } else {
                  this.permissionList.push({ id: permissionItems.id, title: permissionItems.name, ischeck: false })
                }
              })
            })
          }
        })
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
        isDefault: false,
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
      remove(row.id).then(() => {
        this.$notify({
          title: '提示',
          message: '删除成功',
          type: 'success',
          duration: 2000
        })
        this.getList()
      })
    },
    handleSetPermission(row) {
      this.permissionList = []
      this.permissionBindingFormVisible = true
      this.getPermissionList(row)
      this.currentCheckRole = row.id
    },
    setPermission() {
      const data = {
        RoleID: this.currentCheckRole, PermissionIds: this.permissionGroupList
      }
      setPermission(data).then(response => {
        console.log(response)
        this.$notify({
          title: '提示',
          message: '设置成功',
          type: 'success',
          duration: 2000
        })
      })
      console.log(this.permissionGroupList)
    }
  },
  watch: {
    permissionList() {
      console.log(this.setPermissionState)
      ++this.setPermissionState
    }
  }
}
</script>
