pipeline {
  agent any
  environment {
    APPNAME = "lab01"
    IMAGE = "lab01"
    VERSION ="v1.1"
    REGISTRY="oscarcedeno"
    DOCKER_HUB_LOGIN = credentials('oscarcedeno')
    PORT = "8091"

  }
  stages {
    stage('Build Image') {
      steps {
        sh "pwd"
        sh 'docker build -t $REGISTRY/$IMAGE:$VERSION .'
      }
    }
    stage('Docker push to Docker-hub') {
      steps {
        sh "docker login --username=$DOCKER_HUB_LOGIN_USR --password=$DOCKER_HUB_LOGIN_PSW"
        sh 'docker push $REGISTRY/$APPNAME:$VERSION'
      }
    }
     stage('Deploy Image ') {
      steps {
        sh "docker stop $APPNAME"
        sh "docker rm $APPNAME"
        sh "docker pull $REGISTRY/$IMAGE:$VERSION"
        sh 'docker run -d  --name $APPNAME -p $PORT:80 $REGISTRY/$IMAGE:$VERSION '
      }
    }
  }
}
