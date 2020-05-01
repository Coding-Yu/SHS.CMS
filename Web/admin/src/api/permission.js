/* eslint-disable */
import request from '@/utils/request'
import config from '../Config'

export function getPermissionList(query) {
    return request({
        url: config.BASE_URL + 'permission/GetList',
        method: 'post',
        params: query
    })
}

export function getPermission(id) {
    return request({
        url: config.BASE_URL + 'permission/Get',
        method: 'get',
        params: id
    })
}

export function add(data) {
    return request({
        url: config.BASE_URL + 'permission/Add',
        method: 'post',
        data
    })
}

export function update(data) {
    return request({
        url: config.BASE_URL + 'permission/Update',
        method: 'post',
        data
    })
}

export function remove(id, userId) {
    return request({
        url: config.BASE_URL + 'permission/Delete',
        method: 'post',
        params: { id: id, userId: userId }
    })
}