package hr.kristijanmihaljinac.photomanagementplatform.infrastructure.repository

import com.google.firebase.auth.ktx.auth
import com.google.firebase.ktx.Firebase
import hr.kristijanmihaljinac.photomanagementplatform.domain.repository.IAuthenticationRepository

class AuthenticationRepository : IAuthenticationRepository {

    private val auth by lazy {
        Firebase.auth
    }

    override suspend fun login(email: String, password: String): Boolean {

        var result = true

        auth.signInWithEmailAndPassword(
            email,
            password
        ).addOnCompleteListener {
            if (!it.isSuccessful) {
                 result = false
            }
        }

        return result
    }

    override suspend fun register(email: String, password: String): Boolean {
        var result = true

        auth.createUserWithEmailAndPassword(
            email,
            password
        ).addOnCompleteListener {
            if (!it.isSuccessful) {
                result = false
            }
        }

        return result
    }
}