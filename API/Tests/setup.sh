#!/bin/bash
aws dynamodb delete-table --table-name Exercise
sleep 2
aws dynamodb delete-table --table-name TargetWeight
sleep 2
aws dynamodb create-table --table-name Exercise --attribute-definitions AttributeName=ExerciseName,AttributeType=S AttributeName=DateOfExercise,AttributeType=S --key-schema AttributeName=ExerciseName,KeyType=HASH AttributeName=DateOfExercise,KeyType=RANGE --provisioned-throughput ReadCapacityUnits=5,WriteCapacityUnits=5
sleep 2
aws dynamodb create-table --table-name TargetWeight --attribute-definitions AttributeName=ExerciseName,AttributeType=S --key-schema AttributeName=ExerciseName,KeyType=HASH --provisioned-throughput ReadCapacityUnits=5,WriteCapacityUnits=5
sleep 2
aws dynamodb batch-write-item --request-items file://test_items.json
