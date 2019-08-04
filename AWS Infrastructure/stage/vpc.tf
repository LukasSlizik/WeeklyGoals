resource "aws_vpc" "main_network" {
  cidr_block           = "10.0.0.0/16"
  enable_dns_hostnames = "true"
}
resource "aws_subnet" "public_subnet" {
  vpc_id     = "${aws_vpc.main_network.id}"
  cidr_block = "10.0.1.0/24"
}
