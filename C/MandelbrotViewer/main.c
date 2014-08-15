    /*
    *  simpleServer.c
    *  1917 lab 5
    *
    *  Created by Richard Buckland on 28/01/11.
    *  Copyright 2011 Licensed under Creative Commons SA-BY-NC 3.0.
    *
    */

    #include <stdlib.h>
    #include <stdio.h>
    #include <string.h>
    #include <assert.h>
    #ifdef _WIN32
        #include <winsock2.h>
        #include <ws2tcpip.h>
        #define close closesocket
    #else
        #include <netinet/in.h>
        #include <unistd.h>
    #endif

    int waitForConnection (int serverSocket);
    int makeServerSocket (int portno);
    void serveHTML (int socket);

    #define SIMPLE_SERVER_VERSION 1.0
    #define REQUEST_BUFFER_SIZE 1000
    #define DEFAULT_PORT 7191
    #define NUMBER_OF_PAGES_TO_SERVE 10
    // after serving this many pages the server will halt

    int main (int argc, char* argv[]) {

    #ifdef _WIN32
        WSADATA wsaData;
        WSAStartup((2 << 8) + 2, &wsaData);
    #endif

        puts("************************************");
        printf("Starting Mandelbrot Server %f\n", SIMPLE_SERVER_VERSION);

        int serverSocket = makeServerSocket(DEFAULT_PORT);
        printf("Port: %d\n", DEFAULT_PORT);
        puts("************************************");

        char request[REQUEST_BUFFER_SIZE];
        int numberServed = 0;
        while ( numberServed < NUMBER_OF_PAGES_TO_SERVE) {
            printf("*** So far served %d images ***\n", numberServed);

            int connectionSocket = waitForConnection(serverSocket);
            // wait for a request to be sent from a web browser, open a new
            // connection for this conversation

            // read the first line of the request sent by the browser
            int bytesRead = recv (connectionSocket, request, sizeof(request) - 1, 0);
            assert (bytesRead >= 0);
            // were we able to read any data from the connection?

            // print entire request to the console
            printf (" *** Received http request ***\n %s\n", request);

            //send the browser a simple html page using http
            puts (" *** Sending http response ***");
            serveBMP (connectionSocket);

            // close the connection after sending the page- keep aust beautiful
            close (connectionSocket);
            ++numberServed;
        }

        // close the server connection after we are done- keep aust beautiful
        puts("** shutting down the server **");
        close (serverSocket);

    #ifdef _WIN32
        WSACleanup();
    #endif

        return EXIT_SUCCESS;
    }

    void writeBmpHeader(int socket) {
        char header[] = {0x42, 0x4D, 0x36, 0x04, 0x04, 0x00, 0x00, 0x00, 0x00, 0x00,
        0x36, 0x00, 0x00, 0x00, 0x28, 0x00, 0x00, 0x00, 0x00, 0x02, 0x00, 0x00, 0x00,
        0x02, 0x00, 0x00, 0x01, 0x00, 0x18, 0x00, 0x00, 0x00, 0x00, 0x00, 0x24, 0x00,
        0x00, 0x00, 0x13, 0x0B, 0x00, 0x00, 0x13, 0x0B, 0x00, 0x00, 0x00, 0x00, 0x00,
        0x00, 0x00, 0x00, 0x00, 0x00};

        printf("Sending BMP Header\n");
        send(socket, header, sizeof(header), 0);

    }

    void writeHTTPHeader(int socket) {
        const char* message =
            "HTTP/1.1 200 OK\r\n"
            "Content-Type: image/bmp\r\n"
            "\r\n";

        printf ("Sending HTTP Response: %s\n", message);
        send(socket, message, strlen(message), 0);

    }

    void serveBMP(int socket) {
        writeHTTPHeader(socket);
        writeBmpHeader(socket);

        // 262656 pixels have to be written for the full image.
        // 512 * 512 + 512 (padding)

        //Fill the image with green pixels
        int i = 0;
        int j = 0;

        printf("Sending pixels\r\n");

        for (i = 0; i < 262656; i++) {
            writePixel(socket, 0x4b, 0xc9, 0x2e);
        }


    }

    void writePixel(int socket, char r, char g, char b) {
        send(socket, &b, sizeof(b), 0);
        send(socket, &g, sizeof(g), 0);
        send(socket, &r, sizeof(r), 0);
    }

    int escapeSteps (double x, double y) {

        bool escaped = false;

        for (i = 0; i < 256; i++) {


        }

    }

    // start the server listening on the specified port number
    int makeServerSocket(int portNumber) {

        // create socket
        int serverSocket = socket (AF_INET, SOCK_STREAM, 0);
        assert (serverSocket >= 0);
        // error opening socket

        // bind socket to listening port
        struct sockaddr_in serverAddress;
        serverAddress.sin_family      = AF_INET;
        serverAddress.sin_addr.s_addr = INADDR_ANY;
        serverAddress.sin_port        = htons (portNumber);

        // let the server start immediately after a previous shutdown
        int optionValue = 1;
        setsockopt(serverSocket, SOL_SOCKET, SO_REUSEADDR, &optionValue, sizeof(int));

        int bindSuccess = bind(serverSocket, (struct sockaddr*)&serverAddress, sizeof(serverAddress));

        assert (bindSuccess >= 0);
        // if this assert fails wait a short while to let the operating
        // system clear the port before trying again

        return serverSocket;
    }

    // wait for a browser to request a connection,
    // returns the socket on which the conversation will take place
    int waitForConnection(int serverSocket) {

        // listen for a connection
        const int serverMaxBacklog = 10;
        listen(serverSocket, serverMaxBacklog);

        // accept the connection
        struct sockaddr_in clientAddress;
        socklen_t clientLen = sizeof(clientAddress);
        int connectionSocket = accept(serverSocket, (struct sockaddr*)&clientAddress, &clientLen);
        assert(connectionSocket >= 0);
        // error on accept

        return connectionSocket;
    }
