package hr.kristijanmihaljinac.photomanagementplatform.presentation.nav

import androidx.compose.runtime.Composable
import androidx.compose.ui.platform.LocalContext
import androidx.lifecycle.viewmodel.compose.viewModel
import androidx.navigation.NavHostController
import androidx.navigation.compose.NavHost
import androidx.navigation.compose.composable
import hr.kristijanmihaljinac.photomanagementplatform.presentation.auth.AuthenticationViewModel

@Composable
fun RootNavGraph(navController: NavHostController) {

    val authenticationViewModel = viewModel<AuthenticationViewModel>()
    val context = LocalContext.current;
    NavHost(
        navController = navController,
        route = Graph.ROOT,
        startDestination = Graph.AUTH) {
        authNavGraph(
            navController = navController,
            authenticationViewModel = authenticationViewModel,
            context = context
        )
        composable(route = Graph.ADMIN) {
            //MainScreen()
        }
    }
}