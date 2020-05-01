/* eslint-disable */
import request from '@/utils/request'
import config from '../Config'

export function getCategoryList(query) {
    return request({
        url: config.BASE_URL + 'Category/GetList',
        method: 'post',
        params: query
    })
}

export function getDetail(id) {
    return request({
        url: config.BASE_URL + 'Category/Get',
        method: 'get',
        params: id
    })
}

export function add(data) {
    return request({
        url: config.BASE_URL + 'Category/Add',
        method: 'post',
        data
    })
}

export function update(data) {
    return request({
        url: config.BASE_URL + 'Category/Update',
        method: 'post',
        data
    })
}

export function remove(id, userId) {
    return request({
        url: config.BASE_URL + 'Category/Delete',
        method: 'post',
        params: { id: id, userId: userId }
    })
}