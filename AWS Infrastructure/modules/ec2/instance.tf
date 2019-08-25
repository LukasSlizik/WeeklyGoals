# data "local_file" "install-script" {
#   filename = "${path.module}/install/install.sh"
# }

resource "aws_instance" "instance" {
  ami                         = "${var.ami_id}"
  instance_type               = "${var.instance_type}"
  associate_public_ip_address = true
  key_name                    = "${aws_key_pair.public_key.key_name}"
  monitoring                  = true
  subnet_id                   = "${var.subnet_id}"
  vpc_security_group_ids      = ["${var.allow_ssh_securitygroup_id}"]

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

  #   provisioner "file" {
  #   source = ".\\keys\\workload.pub"
  #   destination = "/home/ubuntu/.ssh/id_rsa.pub"

  #   connection {
  #     host = "${aws_instance.jumphost.public_ip}"
  #     type = "ssh"
  #     user = "ubuntu"
  #     timeout = "1m"
  #     private_key = "${tls_private_key.jumphost_keypair.private_key_pem}"
  #   }
  # }

  # provisioner "remote-exec" {
  #   inline = [
  #     "chmod +x /home/ubuntu/install-jumphost.sh",
  #     "chmod 400 /home/ubuntu/.ssh/id_rsa",
  #     "sudo /home/ubuntu/install-jumphost.sh"
  #   ]

  #   connection {
  #     host        = "${aws_instance.jumphost.public_ip}"
  #     type        = "ssh"
  #     user        = "ubuntu"
  #     timeout     = "1m"
  #     private_key = "${tls_private_key.jumphost_keypair.private_key_pem}"
  #   }
  # }
}
