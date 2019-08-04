resource "aws_internet_gateway" "internet_gateway" {
  vpc_id = "${aws_vpc.main_network.id}"
}

resource "aws_route_table" "publictable" {
  vpc_id = "${aws_vpc.main_network.id}"

}

resource "aws_route" "publicroute" {
  route_table_id         = "${aws_route_table.publictable.id}"
  destination_cidr_block = "0.0.0.0/0"
  gateway_id             = "${aws_internet_gateway.internet_gateway.id}"
}

resource "aws_route_table_association" "internet_gatewaypublic" {
  subnet_id      = "${aws_subnet.public_subnet.id}"
  route_table_id = "${aws_route_table.publictable.id}"
}