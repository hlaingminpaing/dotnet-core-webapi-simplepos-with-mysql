# Use the official Nginx image as the base image
FROM nginx:alpine

# Copy the local files from the frontend directory to Nginx's public HTML folder
COPY . /usr/share/nginx/html

# Expose port 80 to make the web app accessible
EXPOSE 80

# Run the Nginx server when the container starts
CMD ["nginx", "-g", "daemon off;"]
