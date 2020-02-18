/* eslint-disable no-unused-vars */
<template>
  <div>
    <el-table
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
      <el-table-column prop="sex" label="性别" />
      <el-table-column prop="age" label="年龄" />
      <el-table-column prop="role" label="角色" />
      <el-table-column prop="area" label="区域" />
      <el-table-column prop="CreateDate" label="日期" />
      <el-table-column label="操作">
        <template slot-scope="scope">
          <el-button size="mini" @click="dialogTableVisible = true">编辑</el-button>
          <el-button size="mini" @click="handleEdit(scope.$index, scope.row)">编辑</el-button>
          <el-button size="mini" type="danger" @click="handleDelete(scope.$index, scope.row)">删除</el-button>
        </template>
      </el-table-column>
    </el-table>
    <!-- <pagination v-show="total>0" :total="total" :page.sync="listQuery.page" :limit.sync="listQuery.limit" @pagination="getList" /> -->
    <el-dialog title="收货地址" :visible.sync="dialogTableVisible">
    <el-form :model="form">
      <el-form-item label="活动名称" :label-width="formLabelWidth">
        <el-input  auto-complete="off"></el-input>
      </el-form-item>
      <el-form-item label="活动区域" :label-width="formLabelWidth">
        <el-select  placeholder="请选择活动区域">
          <el-option label="区域一" value="shanghai"></el-option>
          <el-option label="区域二" value="beijing"></el-option>
        </el-select>
      </el-form-item>
    </el-form>
    <div slot="footer" class="dialog-footer">
      <el-button @click="dialogTableVisible = false">取 消</el-button>
      <el-button type="primary" @click="dialogTableVisible = false">确 定</el-button>
    </div>
  </el-dialog>
  </div>
</template>

<script>
import {
  fetchList,
  // eslint-disable-next-line no-unused-vars
  fetchUser,
  // eslint-disable-next-line no-unused-vars
  createUser,
  // eslint-disable-next-line no-unused-vars
  updateUser,
  // eslint-disable-next-line no-unused-vars
  deleteUser
} from '@/api/user'
export default {
  data() {
    return {
      dialogTableVisible: false,
      tableData: [],
      tableKey: 0,
      list: null,
      total: 0,
      listLoading: true,
      listQuery: {
        PageNum: 1,
        PageSize: 20
        // Name: undefined,
        // Email: undefined,
        // Phone: undefined,
        // sort: 'id'
      }
    }
  },
  created() {
    this.getList()
  },
  methods: {
    getList() {
      this.listLoading = true
      fetchList(this.listQuery).then(response => {
        this.tableData = response.data
        this.total = 1
        // Just to simulate the time of the request
        setTimeout(() => {
          this.listLoading = false
        }, 1.5 * 1000)
      })
    },
    fetchUser() {}
  }
}
</script>
