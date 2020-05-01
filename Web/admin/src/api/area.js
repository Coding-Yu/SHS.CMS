/* eslint-disable */
import request from '@/utils/request'
import config from '../Config'

export function getAreaList(query) {
    return request({
        url: config.BASE_URL + 'Area/GetList',
        method: 'post',
        params: query
    })
}

export function getDetail(id) {
    return request({
        url: config.BASE_URL + 'Area/Get',
        method: 'get',
        params: { id: id }
    })
}

export function add(data) {
    return request({
        url: config.BASE_URL + 'Area/Add',
        method: 'post',
        data
    })
}

export function update(data) {
    return request({
        url: config.BASE_URL + 'Area/Update',
        method: 'post',
        data
    })
}

export function remove(id, userId) {
    return request({
        url: config.BASE_URL + 'Area/Delete',
        method: 'post',
        params: { id: id, userId: userId }
    })
}