/* eslint-disable */
const getters = {
    sidebar: state => state.app.sidebar,
    device: state => state.app.device,
    token: state => state.user.token,
    avatar: state => state.user.avatar,
    name: state => state.user.name,
    userId: state => state.user.userId,
    addRouters: state => state.permission.routers,
    permission_routers: state => state.permission.routers,
}
export default getters