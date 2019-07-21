module "instance" {
  source = "../modules/ec2"

  ami_id        = "${var.ami_id}"
  instance_type = "${var.instance_type}"
}
