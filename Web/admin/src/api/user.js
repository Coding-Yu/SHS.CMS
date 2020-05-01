/* eslint-disable */
import request from '@/utils/request'
import config from '../Config'
export function login(data) {
    return request({
        url: config.BASE_URL + 'Authentication/RequstToken',
        method: 'post',
        data
    })
}

export function getInfo(data) {
    return request({
        url: config.BASE_URL + 'Authentication/GetUser',
        method: 'get'
            // data: 'token' + data
    })
}

export function logout() {
    return request({
        url: config.BASE_URL + 'Authentication/logout',
        method: 'get'
    })
}

// 获取用户列表
export function getUserList(query) {
    return request({
        url: config.BASE_URL + 'User/GetList',
        method: 'post',
        params: query
    })
}

export function getUser(id) {
    return request({
        url: config.BASE_URL + 'user/Get',
        method: 'get',
        params: id
    })
}

export function createUser(data) {
    return request({
        url: config.BASE_URL + 'user/Add',
        method: 'post',
        data
    })
}

export function updateUser(data) {
    return request({
        url: config.BASE_URL + 'user/Update',
        method: 'post',
        data
    })
}

export function deleteUser(id, userId) {
    return request({
        url: config.BASE_URL + 'user/delete',
        method: 'get',
        params: { id: id, userId: userId }
    })
}