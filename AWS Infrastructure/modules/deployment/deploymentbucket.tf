resource "aws_s3_bucket" "deployment-bucket" {
  bucket        = "personalgoals-deployment-bucket"
  acl           = "private"
  force_destroy = "true"

  versioning {
    enabled = true
  }

  lifecycle_rule {
    id      = "delete old files"
    enabled = "true"
    prefix  = "/"

    noncurrent_version_expiration {
      days = 7
    }

  }
}
