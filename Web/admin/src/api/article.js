/* eslint-disable */
import request from '@/utils/request'
import config from '../Config'

export function getArticleList(query) {
    return request({
        url: config.BASE_URL + 'Article/GetList',
        method: 'post',
        params: query
    })
}

export function getDetail(id) {
    return request({
        url: config.BASE_URL + 'Article/Get',
        method: 'get',
        params: { id: id }
    })
}

export function add(data) {
    return request({
        url: config.BASE_URL + 'Article/Add',
        method: 'post',
        data
    })
}

export function update(data) {
    return request({
        url: config.BASE_URL + 'Article/Update',
        method: 'post',
        data
    })
}

export function remove(id, userId) {
    return request({
        url: config.BASE_URL + 'Article/Delete',
        method: 'post',
        params: { id: id, userId: userId }
    })
}