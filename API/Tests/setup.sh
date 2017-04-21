#!/bin/bash
aws dynamodb delete-table --table-name Exercise
aws dynamodb create-table --table-name Exercise --attribute-definitions AttributeName=ExerciseName,AttributeType=S AttributeName=DateOfExercise,AttributeType=S --key-schema AttributeName=ExerciseName,KeyType=HASH AttributeName=DateOfExercise,KeyType=RANGE --provisioned-throughput ReadCapacityUnits=5,WriteCapacityUnits=5
aws dynamodb batch-write-item --request-items file://test_items.json
