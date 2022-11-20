package hr.kristijanmihaljinac.photomanagementplatform.domain.repository

import hr.kristijanmihaljinac.photomanagementplatform.common.Resource

interface IAuthenticationRepository {
    suspend fun login(email: String, password: String): Boolean

    suspend fun  register(email: String, password: String): Boolean
}