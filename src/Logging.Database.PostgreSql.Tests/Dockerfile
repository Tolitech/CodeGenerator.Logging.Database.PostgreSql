# We choose exact tag (not 'latest'), to be sure that new version wont break creating image
FROM postgres:14-alpine

# Set environment variables, not to have to write them with docker run command
ENV POSTGRES_PASSWORD Password@123
ENV POSTGRES_DB Logging

# Copy initialization scripts
COPY create-database.sql /docker-entrypoint-initdb.d

# Expose port 5432 in case accesing from other container
EXPOSE 5432
