module "instance" {
  source = "../modules/ec2"

  ami_id        = "${var.ami_id}"
  instance_type = "${var.instance_type}"
  subnet_id     = "${aws_subnet.public_subnet.id}"
  allow_ssh_securitygroup_id = "${aws_security_group.allow_ssh.id}"
}
