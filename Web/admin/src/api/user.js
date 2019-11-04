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
    url: config.BASE_URL + 'user/GetUserInfo',
    method: 'post',
    data
  })
}

export function logout() {
  return request({
    url: '/user/logout',
    method: 'post'
  })
}
