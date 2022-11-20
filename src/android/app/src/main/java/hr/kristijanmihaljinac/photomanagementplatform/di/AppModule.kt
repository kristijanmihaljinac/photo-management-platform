package hr.kristijanmihaljinac.photomanagementplatform.di

import dagger.Module
import dagger.Provides
import dagger.hilt.InstallIn
import dagger.hilt.components.SingletonComponent
import hr.kristijanmihaljinac.photomanagementplatform.domain.repository.IAuthenticationRepository
import hr.kristijanmihaljinac.photomanagementplatform.infrastructure.repository.AuthenticationRepository
import javax.inject.Singleton

@Module
@InstallIn(SingletonComponent::class)
object AppModule {

    @Provides
    @Singleton
    fun provideAuthRepository() : IAuthenticationRepository{
        return AuthenticationRepository()
    }
}