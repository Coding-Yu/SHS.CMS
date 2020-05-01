/* eslint-disable */
import request from '@/utils/request'
import config from '../Config'

export function getTagList(query) {
    return request({
        url: config.BASE_URL + 'Tag/GetList',
        method: 'post',
        params: query
    })
}

export function getDetail(id) {
    return request({
        url: config.BASE_URL + 'Tag/Get',
        method: 'get',
        params: id
    })
}

export function add(data) {
    return request({
        url: config.BASE_URL + 'Tag/Add',
        method: 'post',
        data
    })
}

export function update(data) {
    return request({
        url: config.BASE_URL + 'Tag/Update',
        method: 'post',
        data
    })
}

export function remove(id, userId) {
    return request({
        url: config.BASE_URL + 'Tag/Delete',
        method: 'post',
        params: { id: id, userId: userId }
    })
}