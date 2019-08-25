#!/bin/bash

cd /home/ec2-user
sudo yum -y -q update
# sudo yum -y -q install ruby
# sudo yum -y -q install wget

# Docker CE Install
sudo amazon-linux-extras install -y docker
sudo service docker start
sudo usermod -a -G docker ec2-user

# Make docker auto-start
sudo chkconfig docker on

# sudo yum remove docker docker-engine docker.io containerd runc
# sudo yum install -y -q \
#     apt-transport-https \
#     ca-certificates \
#     curl \
#     gnupg-agent \
#     software-properties-common

# curl -fsSL https://download.docker.com/linux/ubuntu/gpg | sudo apt-key add -

# sudo add-apt-repository \
#    "deb [arch=amd64] https://download.docker.com/linux/ubuntu \
#    $(lsb_release -cs) \
#    stable"
# sudo yum update

# sudo yum install docker-ce docker-ce-cli containerd.io -yq
