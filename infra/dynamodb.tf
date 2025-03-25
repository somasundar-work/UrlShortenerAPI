resource "aws_dynamodb_table" "urls_table" {
    name           = var.dynamodb_table_urlsTableName
    billing_mode   = "PAY_PER_REQUEST"
    hash_key       = "US_UT_PK"

    attribute {
        name = "US_UT_PK"
        type = "S"
    }

    tags = {
        Name = var.dynamodb_table_urlsTableName
    }
}

resource "aws_dynamodb_table" "analytics_table" {
    name           = var.dynamodb_table_analyticsTableName
    billing_mode   = "PAY_PER_REQUEST"
    hash_key       = "US_UCT_PK"
    global_secondary_index {
        name               = "US_UCT_GSI"
        hash_key           = "US_UCT_GSI_PK"
        projection_type    = "ALL"
    }

    attribute {
        name = "US_UCT_PK"
        type = "S"
    }

    attribute {
        name = "US_UCT_GSI_PK"
        type = "S"
    }

    tags = {
        Name = var.dynamodb_table_analyticsTableName
    }
  
}