FROM php:8.4-apache

# Set working directory
WORKDIR /var/www/html

# Copy application source
COPY . /var/www/html

# Serve files from the public directory
ENV APACHE_DOCUMENT_ROOT=/var/www/html/public
RUN sed -ri -e 's!/var/www/html!${APACHE_DOCUMENT_ROOT}!g' \
        /etc/apache2/sites-available/*.conf \
        /etc/apache2/apache2.conf

EXPOSE 80
CMD ["apache2-foreground"]