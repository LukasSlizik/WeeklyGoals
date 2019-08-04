resource "aws_instance" "instance" {
  ami                         = "${var.ami_id}"
  instance_type               = "${var.instance_type}"
  associate_public_ip_address = true
  key_name                    = "${aws_key_pair.public_key.key_name}"
  monitoring                  = true
  subnet_id                   = "${var.subnet_id}"
  vpc_security_group_ids      = ["${var.allow_ssh_securitygroup_id}"]
}

