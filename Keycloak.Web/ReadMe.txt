
docker run -e KEYCLOAK_ADMIN=admin -e KEYCLOAK_ADMIN_PASSWORD=Password12* -p 8080:8080 quay.io/keycloak/keycloak:24.0.1 start-dev



http://localhost:8080/realms/myrealm/.well-known/openid-configuration


- 1.step
curl --location 'http://localhost:8080/realms/myrealm/protocol/openid-connect/auth/device' \
--header 'Content-Type: application/x-www-form-urlencoded' \
--data-urlencode 'client_id=tv'


- 2.step
curl --location 'http://localhost:8080/realms/myrealm/protocol/openid-connect/token' \
--header 'Content-Type: application/x-www-form-urlencoded' \
--data-urlencode 'grant_type=urn:ietf:params:oauth:grant-type:device_code' \
--data-urlencode 'client_id=tv' \
--data-urlencode 'device_code=6LtVR5pwKbeUiIngw8Tejuuw-bYpgKzYqUhpTdRE3Gk'


http://localhost:8080/realms/myrealm/protocol/openid-connect/auth/device


