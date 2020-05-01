/* eslint-disable */
import Vue from 'vue'
import Router from 'vue-router'

Vue.use(Router)

/* Layout */
import Layout from '@/layout'

/**
 * Note: sub-menu only appear when route children.length >= 1
 * Detail see: https://panjiachen.github.io/vue-element-admin-site/guide/essentials/router-and-nav.html
 *
 * hidden: true                   if set true, item will not show in the sidebar(default is false)
 * alwaysShow: true               if set true, will always show the root menu
 *                                if not set alwaysShow, when item has more than one children route,
 *                                it will becomes nested mode, otherwise not show the root menu
 * redirect: noRedirect           if set noRedirect will no redirect in the breadcrumb
 * name:'router-name'             the name is used by <keep-alive> (must set!!!)
 * meta : {
    roles: ['admin','editor']    control the page roles (you can set multiple roles)
    title: 'title'               the name show in sidebar and breadcrumb (recommend set)
    icon: 'svg-name'             the icon show in the sidebar
    breadcrumb: false            if set false, the item will hidden in breadcrumb(default is true)
    activeMenu: '/example/list'  if set path, the sidebar will highlight the path you set
  }
 */

/**
 * constantRoutes
 * a base page that does not have permission requirements
 * all roles can be accessed
 */
export const constantRoutes = [{
        path: '/login',
        component: () =>
            import ('@/views/login/index'),
        hidden: true
    },

    {
        path: '/404',
        component: () =>
            import ('@/views/404'),
        hidden: true
    },

    {
        path: '/',
        component: Layout,
        redirect: '/dashboard',
        children: [{
            path: 'dashboard',
            name: 'Dashboard',
            component: () =>
                import ('@/views/dashboard/index'),
            meta: { title: '控制面板', icon: 'dashboard' }
        }]
    },

    {
        path: '/centent',
        component: Layout,
        redirect: '/centent/categoryList',
        name: 'centent',
        meta: {
            title: '内容管理',
            icon: 'article'
        },
        children: [{
                path: 'categoryList',
                component: () =>
                    import ('@/views/centent/categoryList/index'),
                name: 'categoryList',
                meta: { title: '分类列表' }
            },
            {
                path: 'articleList',
                name: 'articleList',
                component: () =>
                    import ('@/views/centent/articleList/index'),
                meta: { title: '文章列表' }
            },
            {
                path: 'add',
                name: 'add',
                component: () =>
                    import ('@/views/centent/articleList/add'),
                meta: { title: '添加文章' },
                hidden: true
            },
            {
                path: 'edit',
                name: 'edit',
                component: () =>
                    import ('@/views/centent/articleList/edit'),
                meta: { title: '编辑文章', noCache: true },
                hidden: true
            },
            {
                path: 'tagList',
                name: 'tagList',
                component: () =>
                    import ('@/views/centent/tagList/index'),
                meta: { title: '标签列表', icon: '' }
            }
        ]

    },
    {
        path: '/setting',
        component: Layout,
        redirect: 'noredirect',
        name: 'Setting',
        meta: {
            title: '设置',
            icon: 'setting'
        },
        children: [{
                path: 'userSetting',
                name: 'UserSetting',
                meta: { title: '用户管理', icon: 'user' },
                component: () =>
                    import ('@/views/setting/userSetting/userList'),
                children: [{
                    path: 'userList',
                    name: 'UserList',
                    component: () =>
                        import ('@/views/setting/userSetting/userList'), // Parent router-view
                    meta: { title: '用户列表' }
                }]
            },
            {
                path: 'roleSetting',
                name: 'RoleSetting',
                meta: { title: '角色管理', icon: 'user' },
                component: () =>
                    import ('@/views/setting/roleSetting/roleList'),
                children: [{
                    path: 'roleList',
                    name: 'RoleList',
                    component: () =>
                        import ('@/views/setting/roleSetting/roleList'),
                    meta: { title: '角色列表' }
                }]
            },
            {
                path: 'permissionSetting',
                name: 'PermissionSetting',
                meta: { title: '权限管理', icon: 'user' },
                component: () =>
                    import ('@/views/setting/permissionSetting/permissionList'),
                children: [{
                    path: 'permissionList',
                    name: 'PermissionList',
                    component: () =>
                        import ('@/views/setting/permissionSetting/permissionList'),
                    meta: { title: '权限列表', icon: '' }
                }]
            },
            {
                path: 'AreaSetting',
                name: 'AreaSetting',
                meta: { title: '区域管理', icon: 'user' },
                component: () =>
                    import ('@/views/setting/areaSetting/areaList'),
                children: [{
                    path: 'areaList',
                    name: 'areaList',
                    component: () =>
                        import ('@/views/setting/areaSetting/areaList'),
                    meta: { title: '区域列表', icon: '' }
                }]
            }
        ]
    },

    // 404 page must be placed at the end !!!
    { path: '*', redirect: '/404', hidden: true }
]

const createRouter = () => new Router({
    // mode: 'history', // require service support
    scrollBehavior: () => ({ y: 0 }),
    routes: constantRoutes
})

const router = createRouter()

// Detail see: https://github.com/vuejs/vue-router/issues/1234#issuecomment-357941465
export function resetRouter() {
    const newRouter = createRouter()
    router.matcher = newRouter.matcher // reset router
}
export default router