package hr.kristijanmihaljinac.photomanagementplatform.presentation.nav

import android.content.Context
import android.widget.Toast
import androidx.navigation.NavGraphBuilder
import androidx.navigation.NavHostController
import androidx.navigation.compose.composable
import androidx.navigation.navigation
import hr.kristijanmihaljinac.photomanagementplatform.R
import hr.kristijanmihaljinac.photomanagementplatform.presentation.Screen
import hr.kristijanmihaljinac.photomanagementplatform.presentation.auth.AuthenticationScreen
import hr.kristijanmihaljinac.photomanagementplatform.presentation.auth.AuthenticationViewModel

fun NavGraphBuilder.authNavGraph(
    navController: NavHostController,
    authenticationViewModel: AuthenticationViewModel,
    context: Context
) {
    navigation(
        route = Graph.AUTH,
        startDestination = Screen.AuthScreen.Login.route
    ) {

        composable(route = Screen.AuthScreen.Login.route) {

            AuthenticationScreen(
                icon = R.drawable.login,
                onLogin = {
                    authenticationViewModel.logIn(
                        onSuccess = {
                            navController.popBackStack()
                            navController.navigate(Graph.ADMIN)
                        },
                        onFail = {
                            Toast.makeText(context, context.getString(R.string.unable_to_login), Toast.LENGTH_SHORT).show()
                        }
                    )
                },
                onRegister = {
                    navController.popBackStack()
                    navController.navigate(Screen.AuthScreen.Register.route)
                },
                authenticationState = authenticationViewModel.authenticationState.value,
                onEmailChnaged = { authenticationViewModel.onEmailChanged(it) },
                onPasswordChanged = { authenticationViewModel.onPasswordChanged(it) },
                isLogin = true
            )
        }
        composable(route = Screen.AuthScreen.Register.route) {
            AuthenticationScreen(
                icon = R.drawable.register,
                onRegister = {
                    navController.popBackStack()
                    navController.navigate(Graph.ADMIN)
                },
                onLogin = {
                    authenticationViewModel.register(
                        onSuccess = {
                            navController.popBackStack()
                            navController.navigate(Screen.AuthScreen.Login.route)
                        },
                        onFail = {
                            Toast.makeText(context, context.getString(R.string.unable_to_register), Toast.LENGTH_SHORT).show()
                        }
                    )
                },
                authenticationState = authenticationViewModel.authenticationState.value,
                onEmailChnaged = { authenticationViewModel.onEmailChanged(it) },
                onPasswordChanged = { authenticationViewModel.onPasswordChanged(it) },
                isLogin = false
            )
        }
    }

}