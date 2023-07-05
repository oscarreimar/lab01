pipeline {
  agent any
  stages {
    stage('Build Image'){
      steps {
        sh "pwd"
        sh 'docker build -t lab01:1 .'
      }
    }
  }
}
