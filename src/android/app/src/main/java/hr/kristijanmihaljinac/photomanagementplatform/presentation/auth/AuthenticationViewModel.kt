package hr.kristijanmihaljinac.photomanagementplatform.presentation.auth

import android.util.Patterns
import androidx.compose.runtime.State
import androidx.compose.runtime.mutableStateOf
import androidx.lifecycle.SavedStateHandle
import androidx.lifecycle.ViewModel
import androidx.lifecycle.viewModelScope
import dagger.hilt.android.lifecycle.HiltViewModel
import hr.kristijanmihaljinac.photomanagementplatform.application.use_case.authentication.LoginUseCase
import hr.kristijanmihaljinac.photomanagementplatform.common.Resource
import hr.kristijanmihaljinac.photomanagementplatform.common.isValidPassword
import kotlinx.coroutines.flow.launchIn
import kotlinx.coroutines.flow.onEach
import javax.inject.Inject


@HiltViewModel
class AuthenticationViewModel @Inject constructor(
    private val loginUseCase: LoginUseCase,
    savedStateHandle: SavedStateHandle
) : ViewModel() {

    private val _authenticationState = mutableStateOf(
        AuthenticationState()
    )

    val authenticationState: State<AuthenticationState>
        get() = _authenticationState

    fun onEmailChanged(email: String){
        _authenticationState.value = _authenticationState.value.copy(
            email = email,
            isEmailValid = Patterns.EMAIL_ADDRESS.matcher(email).matches()
        )
    }

    fun onPasswordChanged(password: String){
        _authenticationState.value = _authenticationState.value.copy(
            password = password,
            isPasswordValid = password.isValidPassword()
        )
    }

    fun logIn(
        onSuccess: () -> Unit,
        onFail: () -> Unit){

        loginUseCase(
            _authenticationState.value.email,
            _authenticationState.value.password
        ).onEach { result ->
            when(result){
                is Resource.Success ->
                {

                }
                is Resource.Error -> {

                }
                is Resource.Loading -> {

                }
            }
        }.launchIn(
            viewModelScope
        )
        onSuccess()
        /*AuthenticationRepository.logIn(
            _authenticationState.value.email,
            _authenticationState.value.password,
            onSuccess = onSuccess,
            onFail = onFail
        )*/
    }

    fun register(
        onSuccess: () -> Unit,
        onFail: () -> Unit){
        onSuccess()
/*        AuthenticationRepository.register(
            _authenticationState.value.email,
            _authenticationState.value.password,
            onSuccess = onSuccess,
            onFail = onFail
        )*/
    }
}