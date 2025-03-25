resource "aws_lambda_function" "url_shortener" {
    function_name = var.lambda_function_name
    handler = var.lambda_handler
    runtime = "dotnet8"
    role = aws_iam_role.lambda_exec.arn
    filename = "lambda_package.zip"
    source_code_hash = filebase64sha256("lambda_package.zip")
    environment {
        variables = {
            AWS__Region = var.region
            BaseURL = var.api_gateway_shortener_api_name
            ShortUrl = var.api_gateway_shorturl_api_name
        }
    }
    tags = {
        Name = var.lambda_function_name
    }
  
}

resource "aws_iam_role" "lambda_exec" {
  name = "lambda_exec_role"

  assume_role_policy = <<EOF
  {
    "Version": "2012-10-17",
    "Statement": [
      {
        "Action": "sts:AssumeRole",
        "Principal": {
          "Service": "lambda.amazonaws.com"
        },
        "Effect": "Allow",
        "Sid": ""
      }
    ]
  }
  EOF
}