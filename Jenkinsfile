pipeline {    
 agent any  
  stages {
    stage('Build') {
        steps{
            script{
                sh 'pwd'
                sh 'ls -l'
                sh 'docker-compose -f "/var/lib/jenkins/workspace/dockerLessions_master/docker-compose.yml" up'
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