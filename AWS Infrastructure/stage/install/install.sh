#!/bin/bash

sudo yum -y -q update
sudo yum -y -q install ruby
sudo yum -y -q install wget

cd /home/ec2-user

# Docker CE Install
sudo amazon-linux-extras install -y docker
sudo service docker start
sudo usermod -a -G docker ec2-user

# Make docker auto-start
sudo chkconfig docker on

# Code Deploy Agent
wget https://aws-codedeploy-eu-central-1.s3.eu-central-1.amazonaws.com/latest/install
chmod +x ./install
sudo ./install auto