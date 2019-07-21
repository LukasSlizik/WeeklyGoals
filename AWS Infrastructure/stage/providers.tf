terraform {
  required_version = ">= 0.12.4"
}

provider "aws" {
  region                  = "eu-central-1"
  shared_credentials_file = "~/.aws/credentials"
  profile                 = "personalgoals_deployer"
}
