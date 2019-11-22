pipeline {
 agent any  
  stages {
    stage('Build') {
        steps{
            script{
                sh 'cd "${env.WORKSPACE}" && sudo docker-compose up'
            }
            
        }
        
    }
    
  }

  post {
    success {
      echo 'success'

    }

    failure {
      echo 'failure'

    }

    cleanup {
      echo 'cleanup'

    }

  }
  options {
    buildDiscarder(logRotator(numToKeepStr: '5'))
  }
}