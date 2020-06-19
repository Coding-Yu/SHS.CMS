/* eslint-disable */
import request from '@/utils/request'
import config from '../Config'

export function getLogList(query) {
    return request({
        url: config.BASE_URL + 'Log/GetList',
        method: 'post',
        params: query
    })
}