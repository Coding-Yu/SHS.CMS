/* eslint-disable */
import request from '@/utils/request'
import config from '../Config'

export function getRoleList(query) {
    return request({
        url: config.BASE_URL + 'Role/GetList',
        method: 'post',
        params: query
    })
}

export function getRole(id) {
    return request({
        url: config.BASE_URL + 'Role/Get',
        method: 'get',
        params: id
    })
}

export function add(data) {
    return request({
        url: config.BASE_URL + 'Role/Add',
        method: 'post',
        data
    })
}

export function update(data) {
    return request({
        url: config.BASE_URL + 'Role/Update',
        method: 'post',
        data
    })
}

export function remove(id, userId) {
    return request({
        url: config.BASE_URL + 'Role/Delete',
        method: 'post',
        params: { id: id, userId: userId }
    })
}

export function setPermission(data) {
    return request({
        url: config.BASE_URL + 'Role/SetPermission',
        method: 'post',
        data
    })
}
export function getPermissionByRoleId(id) {
    return request({
        url: config.BASE_URL + 'Role/GetPermissionByRoleId',
        method: 'get',
        params: { id: id }
    })
}