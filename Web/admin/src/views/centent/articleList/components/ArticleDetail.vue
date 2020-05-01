<template>
  <div class="createPost-container">
    <el-form ref="postForm" :model="postForm" :rules="rules" class="form-container">
      <div class="createPost-main-container">
        <el-row >
          <el-col :span="24">
            <el-form-item label="分类：">
              <el-select v-model="postForm.categoryId" placeholder="请选择">
                <el-option
                  v-for="item in categoryOptions"
                  :key="item.id"
                  :label="item.name"
                  :value="item.id">
                </el-option>
              </el-select>
            </el-form-item>
          </el-col>
        </el-row>

        <el-row>
          <el-col :span="24">
            <el-form-item style="margin-bottom: 40px;" prop="title">
              <MDinput v-model="postForm.title" :maxlength="100" name="name" required>
                标题
              </MDinput>
            </el-form-item>
          </el-col>
        </el-row>
        <el-row>
          <el-col :span="24">
            <el-form-item style="margin-bottom: 40px;" prop="summary" required>
              <MDinput v-model="postForm.summary" :maxlength="100" name="summary" >
                简介
              </MDinput>
              <span v-show="contentShortLength" class="word-counter">{{ contentShortLength }}个</span>
            </el-form-item>

          </el-col>
        </el-row>
        <el-form-item>
            <el-tag
            :key="tag"
            v-for="tag in dynamicTags"
            closable
            :disable-transitions="false"
            @close="handleClose(tag)">
            {{tag}}
          </el-tag>
          <el-input
            class="input-new-tag"
            v-if="inputVisible"
            v-model="inputValue"
            ref="saveTagInput"
            size="small"
            @keyup.enter.native="handleInputConfirm"
            @blur="handleInputConfirm"
          >
          </el-input>
          <el-button v-else class="button-new-tag" size="small" @click="showInput">添加标签</el-button>
        </el-form-item>
        <el-form-item style="margin-bottom: 40px;" label-width="80px" label="外链地址:">
          <el-input v-model="postForm.sourceLink" :rows="1" type="textarea" class="article-textarea" autosize placeholder="清输入外链链接地址" />
        </el-form-item>
        <el-form-item prop="content" style="margin-bottom: 30px;">
          <Tinymce ref="editor" v-model="postForm.content" :height="400" />
        </el-form-item>

        <el-row type="flex" class="row-bg" justify="center">
          <el-button v-loading="loading"  type="success" @click="submitForm">
            提交
          </el-button>
          <el-button type="primary">返回</el-button>
        </el-row>
      </div>
    </el-form>
  </div>
</template>
<script>
import Tinymce from '@/components/Tinymce'
// import Upload from '@/components/Upload/SingleImage3'
import MDinput from '@/components/MDinput'
// import Sticky from '@/components/Sticky' // 粘性header组件
import { validURL } from '@/utils/validate'
import { add, getDetail, update } from '@/api/article'
import { getCategoryList } from '@/api/category'
import store from '@/store'
// import { searchUser } from '@/api/remote-search'
// import { CommentDropdown, PlatformDropdown, SourceUrlDropdown } from './Dropdown'

const defaultForm = {
  title: '', // 文章题目
  content: '', // 文章内容
  summary: '', // 文章摘要
  sourceLink: '', // 文章外链
  categoryId: '', // 文章分类
  id: undefined
}

export default {
  name: 'ArticleDetail',
  // components: { Tinymce, MDinput, Upload, Sticky, CommentDropdown, PlatformDropdown, SourceUrlDropdown },
  components: { Tinymce, MDinput },
  props: {
    isEdit: {
      type: Boolean,
      default: false
    }
  },
  data() {
    const validateRequire = (rule, value, callback) => {
      if (value === '') {
        this.$message({
          message: rule.field + '为必传项',
          type: 'error'
        })
        callback(new Error(rule.field + '为必传项'))
      } else {
        callback()
      }
    }
    const validateSourceLink = (rule, value, callback) => {
      if (value) {
        if (validURL(value)) {
          callback()
        } else {
          this.$message({
            message: '外链url填写不正确',
            type: 'error'
          })
          callback(new Error('外链url填写不正确'))
        }
      } else {
        callback()
      }
    }
    return {
      categoryListQuery: {
        page: 1,
        limit: 20
      },
      categoryOptions: [],
      postForm: Object.assign({}, defaultForm),
      loading: false,
      userListOptions: [],
      rules: {
        title: [{ validator: validateRequire }],
        summary: [{ validator: validateRequire }],
        content: [{ validator: validateRequire }],
        sourceLink: [{ validator: validateSourceLink, trigger: 'blur' }]
      },
      dynamicTags: ['标签一', '标签二', '标签三'],
      inputVisible: false,
      inputValue: '',
      tempRoute: {}
    }
  },
  computed: {
    contentShortLength() {
      return this.postForm.summary.length
    },
    displayTime: {
      get() {
        return (+new Date(this.postForm.display_time))
      },
      set(val) {
        this.postForm.display_time = new Date(val)
      }
    }
  },
  created() {
    if (this.postForm.categoryId === '') {
      this.getCategoryData()
    }
    if (this.isEdit) {
      const id = this.$route.query.id
      this.fetchData(id)
    } else {
      this.postForm = Object.assign({}, defaultForm)
    }
    this.tempRoute = Object.assign({}, this.$route)
  },
  methods: {
    getCategoryData() {
      getCategoryList(this.categoryListQuery).then(response => {
        this.categoryOptions = response.data.items
        setTimeout(() => {
          this.listLoading = false
        }, 1.5 * 1000)
      })
    },
    fetchData(id) {
      getDetail(id).then(response => {
        this.postForm = response.data
        this.postForm.title = this.postForm.title
        this.postForm.summary = this.postForm.summary
        this.postForm.sourceLink = this.postForm.sourceLink
        this.postForm.categoryId = this.postForm.categoryId
        this.setViewTitle()
        this.setPageTitle()
      }).catch(err => {
        console.log(err)
      })
    },
    setViewTitle() {
      const title = 'Edit Article'
      Object.assign({}, this.tempRoute, { title: `${title}-${this.postForm.id}` })
    },
    setPageTitle() {
      const title = 'Edit Article'
      document.title = `${title} - ${this.postForm.id}`
    },
    submitForm() {
      this.$refs.postForm.validate(valid => {
        if (valid) {
        // 添加操作前获取用户ID
          if (this.isEdit) {
            this.postForm.UpdateUserId = store.state.user.userId
            update(this.postForm).then(() => {
              this.$notify({
                title: '提示',
                message: '更新成功',
                type: 'success',
                duration: 2000
              })
            })
          } else {
            this.postForm.CreateUserId = store.state.user.userId
            add(this.postForm).then(() => {
              this.$notify({
                title: '提示',
                message: '添加成功',
                type: 'success',
                duration: 2000
              })
            })
          }
        } else {
          console.log('error submit!!')
          return false
        }
      })
    },
    draftForm() {
      if (this.postForm.content.length === 0 || this.postForm.title.length === 0) {
        this.$message({
          message: '请填写必要的标题和内容',
          type: 'warning'
        })
        return
      }
      this.$message({
        message: '保存成功',
        type: 'success',
        showClose: true,
        duration: 1000
      })
    },
    getRemoteUserList(query) {
      // searchUser(query).then(response => {
      //   if (!response.data.items) return
      //   this.userListOptions = response.data.items.map(v => v.name)
      // })
    },
    handleClose(tag) {
      this.dynamicTags.splice(this.dynamicTags.indexOf(tag), 1)
    },

    showInput() {
      this.inputVisible = true
      this.$nextTick(_ => {
        this.$refs.saveTagInput.$refs.input.focus()
      })
    },

    handleInputConfirm() {
      const inputValue = this.inputValue
      if (inputValue) {
        this.dynamicTags.push(inputValue)
      }
      this.inputVisible = false
      this.inputValue = ''
    }
  }
}
</script>

<style lang="scss" scoped>
@import "~@/styles/mixin.scss";

.createPost-container {
  position: relative;

  .createPost-main-container {
    padding: 40px 45px 20px 50px;

    .postInfo-container {
      position: relative;
      @include clearfix;
      margin-bottom: 10px;

      .postInfo-container-item {
        float: left;
      }
    }
  }

  .word-counter {
    width: 40px;
    position: absolute;
    right: 10px;
    top: 0px;
  }
}

.article-textarea /deep/ {
  textarea {
    padding-right: 40px;
    resize: none;
    border: none;
    border-radius: 0px;
    border-bottom: 1px solid #bfcbd9;
  }
}
 .el-tag + .el-tag {
    margin-left: 10px;
  }
  .button-new-tag {
    margin-left: 10px;
    height: 32px;
    line-height: 30px;
    padding-top: 0;
    padding-bottom: 0;
  }
  .input-new-tag {
    width: 90px;
    margin-left: 10px;
    vertical-align: bottom;
  }
</style>
