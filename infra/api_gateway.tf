resource "aws_api_gateway_rest_api" "shorturl_api" {
    name        = var.api_gateway_shorturl_api_name
    description = var.api_gateway_shorturl_api_name
}

resource "aws_api_gateway_rest_api" "shortener_api" {
    name        = var.api_gateway_shortener_api_name
    description = var.api_gateway_shortener_api_name
}