variable "region" {
    description = "The AWS region to deploy resources in"
    type        = string
    default     = "ap-south-1"
}

variable "lambda_function_name" {
    description = "The name of the Lambda function"
    type        = string
    default     = "my-url-shortener-function"
}

variable "dynamodb_table_urlsTableName" {
    description = "The name of the DynamoDB table to store URLs"
    type        = string
    default     = "my-url-shortener-urls-table"
}

variable "dynamodb_table_analyticsTableName" {
    description = "The name of the DynamoDB table to store analytics"
    type        = string
    default     = "my-url-shortener-analytics-table"
}

variable "api_gateway_shorturl_api_name" {
    description = "The name of the API Gateway REST API"
    type        = string
    default     = "my-url-shorturl-api"
}

variable "api_gateway_shortener_api_name" {
    description = "The name of the API Gateway REST API"
    type        = string
    default     = "my-url-shortener-api"
}

variable "lambda_handler" {
    description = "The name of the Lambda handler function"
    type        = string
    default     = "UrlShortener.API::UrlShortener.API.LambdaEntryPoint::FunctionHandlerAsync"
  
}