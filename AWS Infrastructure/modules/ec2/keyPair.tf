resource "tls_private_key" "ec2_keypair" {
  algorithm = "RSA"
  rsa_bits  = 4096
}

resource "aws_key_pair" "public_key" {
  key_name   = "jumphost-key"
  public_key = "${tls_private_key.ec2_keypair.public_key_openssh}"
}

resource "local_file" "private_key" {
  content    = "${tls_private_key.ec2_keypair.private_key_pem}"
  filename   = "./keys/jumphost"
}

resource "local_file" "public_key" {
  content    = "${tls_private_key.ec2_keypair.public_key_pem}"
  filename   = "./keys/jumphost.pub"
}