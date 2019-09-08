resource "aws_instance" "instance" {
  ami                         = "${var.ami_id}"
  instance_type               = "${var.instance_type}"
  associate_public_ip_address = true
  key_name                    = "${aws_key_pair.public_key.key_name}"
  monitoring                  = true
  subnet_id                   = "${var.subnet_id}"
  vpc_security_group_ids      = ["${var.allow_ssh_securitygroup_id}"]

  tags = {
    DeployGroup = "server"
  }

  provisioner "file" {
    source      = "install/install.sh"
    destination = "/home/ec2-user/install.sh"

    connection {
      host        = "${aws_instance.instance.public_ip}"
      type        = "ssh"
      user        = "ec2-user"
      timeout     = "1m"
      private_key = "${tls_private_key.ec2_keypair.private_key_pem}"
    }
  }

  provisioner "remote-exec" {
    inline = [
      "chmod +x /home/ec2-user/install.sh",
      "sudo /home/ec2-user/install.sh"
    ]

    connection {
      host        = "${aws_instance.instance.public_ip}"
      type        = "ssh"
      user        = "ec2-user"
      timeout     = "1m"
      private_key = "${tls_private_key.ec2_keypair.private_key_pem}"
    }
  }
}
