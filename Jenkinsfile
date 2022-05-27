pipeline {
    agent any
    environment {
        IMAGE = 'backend:alpha'
    }
    stages {
        stage('Before Build') {
            steps {
                echo 'Before build'
                echo "Id: ${BUILD_ID}, Branch: ${BRANCH_NAME}, Job: ${JOB_NAME}, Url: ${BUILD_URL}"
            }
        }
        stage('Build') {
            steps {
                echo 'Build image'
                sh "docker build -t ${IMAGE} ."
            }
        }
        stage('Docker Compose Down') {
            steps {
                echo 'docker-compose down'
                sh 'docker-compose down'
            }
        }
        stage('Docker Compose Up') {
            steps {
                echo 'docker-compose up -d'
                sh 'docker-compose up -d'
            }
        }
    }
    post {
        always {
            echo "id: ${env.BUILD_ID}, url: ${env.BUILD_URL} always run"
        }
        success {
            echo "id: ${env.BUILD_ID}, url: ${env.BUILD_URL} run only if successful"
        }
        failure {
            echo "id: ${env.BUILD_ID}, url: ${env.BUILD_URL} run only if failed"
        }
    }
}