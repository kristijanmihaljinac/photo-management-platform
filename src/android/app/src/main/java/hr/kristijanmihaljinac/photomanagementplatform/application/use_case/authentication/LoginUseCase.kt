package hr.kristijanmihaljinac.photomanagementplatform.application.use_case.authentication

import hr.kristijanmihaljinac.photomanagementplatform.common.Resource
import hr.kristijanmihaljinac.photomanagementplatform.domain.repository.IAuthenticationRepository
import kotlinx.coroutines.flow.Flow
import kotlinx.coroutines.flow.flow
import retrofit2.HttpException
import javax.inject.Inject

class LoginUseCase @Inject constructor(
    private val repository: IAuthenticationRepository
) {
    operator fun invoke(email: String, password: String) : Flow<Resource<Boolean>> = flow {
        try {
            emit(Resource.Loading<Boolean>(true))
            val isLogedIn = repository.login(
                email,
                password
            )

            if (isLogedIn){
                emit(Resource.Success(true))
            }
            else {
                emit(Resource.Error("Wrong email or password"))
            }
        }
        catch (e: HttpException){
            emit(Resource.Error<Boolean>(e.localizedMessage ?: "An unexpected error occured"))
        }
    }
}