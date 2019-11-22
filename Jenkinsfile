pipeline {    
 agent any  
  stages {
    stage('Build') {
        steps{
            script{
                sh 'sudo docker-compose -f ./docker-compose.yml up'
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