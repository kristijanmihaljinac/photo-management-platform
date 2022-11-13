package hr.kristijanmihaljinac.photomanagementplatform.presentation

import android.os.Bundle
import androidx.activity.ComponentActivity
import androidx.activity.compose.setContent
import androidx.compose.material.Surface
import androidx.navigation.compose.rememberNavController
import hr.kristijanmihaljinac.photomanagementplatform.presentation.nav.RootNavGraph
import hr.kristijanmihaljinac.photomanagementplatform.presentation.ui.theme.PhotoManagementPlatformTheme

class MainActivity : ComponentActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContent {
            PhotoManagementPlatformTheme {
                Surface {
                    RootNavGraph(navController = rememberNavController())
                }
            }
        }
    }
}

