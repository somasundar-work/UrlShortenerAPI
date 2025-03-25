terraform {
    required_providers {
        aws = {
            source = "hashicorp/aws"
            version = "~> 5.0"
        }
    }
    backend "s3" {
        bucket = "my-terraform-state-bucket"
        key = "terraform.tfstate"
        region = "ap-south-1"
        dynamodb_table = "my-terraform-state-lock-table"
        encrypt = true
    }
}

provider "aws" {
    region = var.region
}