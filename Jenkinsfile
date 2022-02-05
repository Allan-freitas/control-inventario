pipeline {
    agent any

    stages {
        stage('Restore packages') {
            steps {
                echo 'Restoring...'
				echo "${workspace}"
				sh "dotnet restore ${workspace}/src/Qualite.Ingenieria/Qualite.Ingenieria.sln"
            }
        }
		stage('Build') {
            steps {
                echo 'Building...'
				sh "dotnet build ${workspace}/src/Qualite.Ingenieria/Qualite.Ingenieria.sln"
            }
        }
		stage("Tests"){
            steps {
                sh "dotnet test ${workspace}/src/Qualite.Ingenieria/Qualite.Ingenieria.sln /p:CollectCoverage=true /p:CoverletOutputFormat=opencover /p:CoverletOutput='/var/lib/jenkins/workspace/Net5_main/src/Qualite.Ingenieria/Application.Tests/results/result.xml' --no-build"
            }
        }
		stage('Coverage') {
			environment {
				scannerHome = tool 'SonarQubeScanner'
			}
			steps {
				withSonarQubeEnv('sonarqube') {
					 sh "dotnet ${scannerHome}/SonarScanner.MSBuild.dll begin /k:'Net5' /d:sonar.cs.opencover.reportsPaths='/var/lib/jenkins/workspace/Net5_main/src/Qualite.Ingenieria/Application.Tests/results/result.xml' /d:sonar.test.exclusions='test/**'"
				}
			}
		}
		stage('Sonarqube') {			
			environment {
				scannerHome = tool 'SonarQubeScanner'
			}
			steps {
				echo 'Analisando o que você fez...'
				withSonarQubeEnv('sonarqube') {
					sh "dotnet restore ${workspace}/src/Qualite.Ingenieria/Qualite.Ingenieria.sln"
					sh ("""dotnet ${scannerHome}/SonarScanner.MSBuild.dll begin /k:'Net5'""")
					sh "dotnet build ${workspace}/src/Qualite.Ingenieria/Qualite.Ingenieria.sln"
					sh "dotnet ${scannerHome}/SonarScanner.MSBuild.dll end"
				}
				timeout(time: 1, unit: 'MINUTES') {
					waitForQualityGate abortPipeline: true
				}
			}
		}
        stage('Deploy') {
            steps {
                echo 'Deploying....'
            }
        }
    }
}